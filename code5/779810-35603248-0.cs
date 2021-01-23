    async static Task Start(string url, Action<byte[]> action, int bufSize = 1024, CancellationToken? tk = null) {
        var myTk = tk.HasValue ? tk.Value : CancellationToken.None;
        using(var cli = new HttpClient()) {
            var streamBuffer = new byte[bufSize];
            // Give it the maximum size in bytes of your picture
            var frameBuffer = new List<byte>(1024 * 1024);
            var ff = false;
            var inPic = false;
            using(var stream = await cli.GetStreamAsync(url).ConfigureAwait(false)) {
                while(!myTk.IsCancellationRequested) {
                    var l = await stream.ReadAsync(streamBuffer, 0, bufSize).ConfigureAwait(false);
                    var idx = 0;
                    while(idx < l) {
                        var c = streamBuffer[idx++];
                        // We have found a FF
                        if(c == 0xff) {
                            ff = true;
                        }
                        // We found a JPEG picture start
                        else if(ff && c == 0xd8) {
                            frameBuffer.Clear();
                            frameBuffer.Add(0xff);
                            frameBuffer.Add(0xd8);
                            if(inPic) {
                                Console.WriteLine("Skipped frame : end expected");
                            }
                            ff = false;
                            inPic = true;
                        }
                        // We found a JPEG picture end
                        else if(ff && c == 0xd9) {
                            frameBuffer.Add(0xff);
                            frameBuffer.Add(0xd9);
                            // Send the JPEG picture as an event
                            action(frameBuffer.ToArray());
                            ff = false;
                            if(!inPic) {
                                Console.WriteLine("Skipped frame : start expected");
                            }
                            inPic = false;
                        }
                        // We are inside a JPEG picture
                        else if(inPic) {
                            if(ff) {
                                frameBuffer.Add(0xff);
                                ff = false;
                            }
                            frameBuffer.Add(c);
                        }
                    }
                }
            }
        }
    }
