            int Min = 0;
            int Max = 6;
            // this declares an integer array with 5 elements
            // and initializes all of them to their default value
            // which is zero
            //int[] test2 = new int[6];
            int[] test2 = Enumerable.Range(Min, Max).OrderBy(n => Guid.NewGuid()).Select(n => n).ToArray();
            arrayListbox.ItemsSource = test2;
            arrayListboxOrder.ItemsSource = test2.OrderBy(a => a).ToArray();
