    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Console_21737681
    {
        class Program
        {
            const int MAX_PARALLEL = 4; // max parallel downloads
            const int CHUNK_SIZE = 2048; // size of a single chunk
    
            // a chunk of downloaded data
            class Chunk
            {
                public long Start { get; set; }
                public int Length { get; set; }
                public byte[] Data { get; set; }
            };
    
            // throttle downloads
            SemaphoreSlim _throttleSemaphore = new SemaphoreSlim(MAX_PARALLEL);
    
            // get a chunk
            async Task<Chunk> GetChunk(HttpClient client, long start, int length, string url)
            {
                await _throttleSemaphore.WaitAsync();
                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        request.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(start, start + length - 1);
                        using (var response = await client.SendAsync(request))
                        {
                            var data = await response.Content.ReadAsByteArrayAsync();
                            return new Chunk { Start = start, Length = length/*, Data = data*/ };
                        }
                    }
                }
                finally
                {
                    _throttleSemaphore.Release();
                }
            }
    
            // download the URL in parallel by chunks
            async Task<Chunk[]> DownloadAsync(string url)
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Head, url);
                    var response = await client.SendAsync(request);
                    var contentLength = response.Content.Headers.ContentLength;
    
                    if (!contentLength.HasValue)
                        throw new InvalidOperationException("ContentLength");
    
                    var numOfChunks = (int)((contentLength.Value + CHUNK_SIZE -1) / CHUNK_SIZE);
    
                    var tasks = Enumerable.Range(0, numOfChunks-1).Select((i) =>
                    {
                        // start new chunk
                        long start = i * CHUNK_SIZE;
                        var length = (int)Math.Min(CHUNK_SIZE, contentLength.Value - start);
                        return GetChunk(client, start, length, url);
                    });
    
                    await Task.WhenAll(tasks);
    
                    // the order of chunks is random
                    return tasks.Select((task) =>
                        task.Result).ToArray();
                }
            }
    
            static void Main(string[] args)
            {
                var program = new Program();
                var chunks = program.DownloadAsync("http://flaglane.com/download/australian-flag/australian-flag-large.png").Result;
    
                Console.WriteLine("Chunks: " + chunks.Length);
                Console.ReadLine();
            }
        }
    }
