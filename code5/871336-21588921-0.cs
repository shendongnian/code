        [DebuggerStepThrough]
        public static void Interupt(int Index, string Text)
        {
            try
            {
                Change(Transforms[Index], Text);
            }
            catch
            {
                throw new System.InvalidOperationException("Index: " + Index + " Is too large should be less than: " + Transforms.Count); // points me here
            }
        }
