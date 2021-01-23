        // PCL Project
        public interface INativePages
        {
            void StartMA();
        }
    
        // MonoDroid Project
        [assembly: Dependency(typeof(NativePages))]
        public class NativePages : INativePages
        {
            public void StartMA()
            {
                var intent = new Intent(Forms.Context, typeof(MAActivity));
                Forms.Context.StartActivity(intent);
            }
        }
