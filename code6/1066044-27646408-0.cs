        [Conditional("CONTRACTS_FULL"), ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), __DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void Requires(bool condition);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), __DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void Requires<TException>(bool condition) where TException: Exception;
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), Conditional("CONTRACTS_FULL"), __DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void Requires(bool condition, string userMessage);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), __DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void Requires<TException>(bool condition, string userMessage) where TException: Exception;
