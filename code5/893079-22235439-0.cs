        ///     WPF 4.0 had a performance optimization where it would
        ///     frequently reuse the same instance of the
        ///     DispatcherSynchronizationContext when preparing the
        ///     ExecutionContext for invoking a DispatcherOperation.  This
        ///     had observable impacts on behavior.
        ///
        ///     1) Some task-parallel implementations check the reference
        ///         equality of the SynchronizationContext to determine if the
        ///         completion can be inlined - a significant performance win.
        ///
        ///     2) But, the ExecutionContext would flow the
        ///         SynchronizationContext which could result in the same
        ///         instance of the DispatcherSynchronizationContext being the
        ///         current SynchronizationContext on two different threads.
        ///         The continuations would then be inlined, resulting in code
        ///         running on the wrong thread.
        ///
        ///     In 4.5 we changed this behavior to use a new instance of the
        ///     DispatcherSynchronizationContext for every operation, and
        ///     whenever SynchronizationContext.CreateCopy is called - such
        ///     as when the ExecutionContext is being flowed to another thread.
        ///     This has its own observable impacts:
        ///
        ///     1) Some task-parallel implementations check the reference
        ///         equality of the SynchronizationContext to determine if the
        ///         completion can be inlined - since the instances are
        ///         different, this causes them to resort to the slower
        ///         path for potentially cross-thread completions.
        ///
        ///     2) Some task-parallel implementations implement potentially
        ///         cross-thread completions by callling
        ///         SynchronizationContext.Post and Wait() and an event to be
        ///         signaled.  If this was not a true cross-thread completion,
        ///         but rather just two seperate instances of
        ///         DispatcherSynchronizationContext for the same thread, this
        ///         would result in a deadlock.
