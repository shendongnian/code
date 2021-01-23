    message=The type initializer for 'System.Web.Util.ExecutionContextUtil' threw an exception.
    stack= at System.Web.Util.ExecutionContextUtil.RunInNullExecutionContext(Action callback)
    at System.Web.Hosting.ObjectCacheHost.System.Runtime.Caching.Hosting.IMemoryCacheManager.UpdateCacheSize(Int64 size, MemoryCache memoryCache)
    at System.Runtime.Caching.CacheMemoryMonitor.GetCurrentPressure()
    at System.Runtime.Caching.MemoryMonitor.Update()
    at System.Runtime.Caching.MemoryCacheStatistics.CacheManagerThread(Int32 minPercent)
    at System.Runtime.Caching.MemoryCacheStatistics.CacheManagerTimerCallback(Object state)
    at System.Threading._TimerCallback.TimerCallback_Context(Object state)
    at System.Threading.ExecutionContext.runTryCode(Object userData)
    at System.Runtime.CompilerServices.RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(TryCode code, CleanupCode backoutCode, Object userData)
    at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
    at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean ignoreSyncCtx)
    at System.Threading._TimerCallback.PerformTimerCallback(Object state)
    type=System.Exception
    message=Type 'System.Threading.ExecutionContext' does not have a public property named 'PreAllocatedDefault'.
    stack=at System.Web.Util.ExecutionContextUtil.GetDummyDefaultEC()
    at System.Web.Util.ExecutionContextUtil..cctor()
