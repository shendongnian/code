    using System.Threading;
    using Common.FluentValidation;
    using System;
    namespace Common.Environment
    {
        public static partial class Sleep
        {
            /// <summary>
            /// Block the current thread for a specified amount of time.
            /// </summary>
            /// <param name="p_milliseconds">Time to block for.</param>
            /// <param name="p_cancelToken">External token for waking thread early.</param>
            /// <returns>True if sleeping was cancelled before timer expired.</returns>
            public static bool For(int p_milliseconds, CancellationToken p_cancelToken = default(CancellationToken))
            {
                // Used as "No-Op" during debug
                if (p_milliseconds == 0)
                    return false;
                // Validate
                p_milliseconds
                    .MustBeEqualOrAbove(0, "p_milliseconds");
                // Merge Tokens and block on either
                CancellationToken LocalToken = new CancellationToken();
                using (var SleeperSource = CancellationTokenSource.CreateLinkedTokenSource(LocalToken, p_cancelToken))
                {
                    SleeperSource
                        .Token
                        .WaitHandle
                        .WaitOne(p_milliseconds);
                    
                    return SleeperSource.IsCancellationRequested;
                }
            }
        }
    }
