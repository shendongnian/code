        private static void CheckValue<T>(T temp, ref T variable) where T : class
        {
            if (temp != variable)
            {
                variable = temp;
                EditorUtility.SetDirty(target);
            }
        }
