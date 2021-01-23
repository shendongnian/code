            int[] arr1= new int[] {1,2,5,6,7,9,3,5,6,7};
            int[] arr2 = new int[] {5,6,7};
            var listCommon = arr1.AsEnumerable().Where(arr2.AsEnumerable().Contains);
            foreach (var x in listCommon.Distinct()) {
                var numberOfOccurencesInArr1 = arr1.Where(y => y == x).Count();
                Console.WriteLine(x + " is : " + numberOfOccurencesInArr1.ToString() + " times in arr1");
            }
            Console.ReadLine();
