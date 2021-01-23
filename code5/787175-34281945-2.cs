    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Net.Http;
    using System.Threading;
    using System.Diagnostics;
    using System.Net;
    using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
    namespace HttpClientRetyDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var url = "http://RestfulUrl";
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                var handler = new RetryDelegatingHandler
                {
                    UseDefaultCredentials = true,
                    PreAuthenticate = true,
                    Proxy = null
                };
                HttpClient client = new HttpClient(handler);
                var result = client.SendAsync(httpRequestMessage).Result.Content
                    .ReadAsStringAsync().Result;
                Console.WriteLine(result.ToString());
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Retry Policy = Error Detection Strategy + Retry Strategy
        /// </summary>
        public static class CustomRetryPolicy
        {
            public static RetryPolicy MakeHttpRetryPolicy()
            {
                // The transient fault application block provides three retry policies
                //  that you can use. These are:
                return new RetryPolicy(strategy, exponentialBackoff);
            }
        }
        /// <summary>
        /// This class is responsible for deciding whether the response was an intermittent
        /// transient error or not.
        /// </summary>
        public class HttpTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
        {
            public bool IsTransient(Exception ex)
            {
                if (ex != null)
                {
                    HttpRequestExceptionWithStatus httpException;
                    if ((httpException = ex as HttpRequestExceptionWithStatus) != null)
                    {
                        if (httpException.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            return true;
                        }
                        else if (httpException.StatusCode == HttpStatusCode.MethodNotAllowed)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// The retry handler logic is implementing within a Delegating Handler. This has a
        /// number of advantages.
        /// An instance of the HttpClient can be initialized with a delegating handler making
        /// it super easy to add into the request pipeline.
        /// It also allows you to apply your own custom logic before the HttpClient sends the
        /// request, and after it receives the response.
        /// Therefore it provides a perfect mechanism to wrap requests made by the HttpClient
        /// with our own custom retry logic.
        /// </summary>
        class RetryDelegatingHandler : HttpClientHandler
        {
            public RetryPolicy retryPolicy { get; set; }
            public RetryDelegatingHandler()
                : base()
            {
                retryPolicy = CustomRetryPolicy.MakeHttpRetryPolicy();
            }
            protected async override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                HttpResponseMessage responseMessage = null;
                var currentRetryCount = 0;
                //On Retry => increments the retry count
                retryPolicy.Retrying += (sender, args) =>
                {
                    currentRetryCount = args.CurrentRetryCount;
                };
                try
                {
                    await retryPolicy.ExecuteAsync(async () =>
                    {
                        responseMessage = await base.SendAsync(request, cancellationToken)
                            .ConfigureAwait(false);
                        if ((int)responseMessage.StatusCode > 500)
                        {
                            // When it fails after the retries, it would throw the exception
                            throw new HttpRequestExceptionWithStatus(
                                string.Format("Response status code {0} indicates server error",
                                    (int)responseMessage.StatusCode))
                            {
                                StatusCode = responseMessage.StatusCode,
                                CurrentRetryCount = currentRetryCount
                            };
                        }// returns the response to the main method(from the anonymous method)
                        return responseMessage;
                    }, cancellationToken).ConfigureAwait(false);
                    return responseMessage;// returns from the main method => SendAsync
                }
                catch (HttpRequestExceptionWithStatus exception)
                {
                    if (exception.CurrentRetryCount >= 3)
                    {
                        //write to log
                    }
                    if (responseMessage != null)
                    {
                        return responseMessage;
                    }
                    throw;
                }
                catch (Exception)
                {
                    if (responseMessage != null)
                    {
                        return responseMessage;
                    }
                    throw;
                }
            }
        }
        /// <summary>
        /// Custom HttpRequestException to allow include additional properties on my exception,
        /// which can be used to help determine whether the exception is a transient
        /// error or not.
        /// </summary>
        public class HttpRequestExceptionWithStatus : HttpRequestException
        {
            public HttpStatusCode StatusCode { get; set; }
            public int CurrentRetryCount { get; set; }
            public HttpRequestExceptionWithStatus()
                : base() { }
            public HttpRequestExceptionWithStatus(string message)
                : base(message) { }
            public HttpRequestExceptionWithStatus(string message, Exception inner)
                : base(message, inner) { }
        }
    }
