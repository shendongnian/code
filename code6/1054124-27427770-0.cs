       /*========================================================================
        ** Sends a notification to all waiting objects. 
        ========================================================================*/
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void ObjPulseAll(Object obj);
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        public static void PulseAll(Object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            Contract.EndContractBlock();
 
            ObjPulseAll(obj);
        }
