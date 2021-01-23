    public static class Util {
            public static void AddAll<T>(this Stack<T> stack1, Stack<T> stack2) {
                T[] arr = new T[stack2.Count];
                stack2.CopyTo(arr, 0);
    
                for (int i = arr.Length - 1; i >= 0; i--) {
                    stack1.Push(arr[i]);
                }
            }
        }
