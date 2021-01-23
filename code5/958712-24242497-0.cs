    unsafe {
        int[] arr = new[] { 1, 2 };
        fixed(int* ptr = arr) {
            for(int i = 0; i < arr.Length + 1; i++) {
                try { System.Console.WriteLine(*(ptr + i)); } catch(Exception e) { System.Console.WriteLine(e.Message); }
                try { System.Console.WriteLine(ptr[i]); } catch (Exception e) { System.Console.WriteLine(e.Message); }
                try { System.Console.WriteLine(arr[i]); } catch (Exception e) { System.Console.WriteLine(e.Message); }
            }
        }
    }
