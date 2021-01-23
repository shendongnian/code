    class Program
    {
        public static void Main()
        {
            List<int> bundleSizes = new List<int> { 46, 25, 12, 4, 3 };
            int quantity = 30;
            Dictionary<int, int> bundleResults = StackThis(bundleSizes, quantity);
            Output(bundleSizes, quantity, bundleResults);
            quantity = 17;
            bundleResults = StackThis(bundleSizes, quantity);
            Output(bundleSizes, quantity, bundleResults);
            quantity = 47;
            bundleResults = StackThis(bundleSizes, quantity);
            Output(bundleSizes, quantity, bundleResults);
            quantity = 5;
            bundleResults = StackThis(bundleSizes, quantity);
            Output(bundleSizes, quantity, bundleResults);
            Console.Read();
        }
        // Reused paqogomez output
        static void Output(List<int> bundleSizes, int quantity, Dictionary<int, int> bundleResults)
        {
            var fullResults = new Dictionary<int, int>();
            bundleSizes.ForEach(
                delegate(int e)
                {
                    var result = 0;
                    if (bundleResults != null)
                        bundleResults.TryGetValue(e, out result);
                    fullResults.Add(e, result);
                });
            Console.WriteLine("Bundle Sizes: {0}", string.Join(",", bundleSizes));
            Console.WriteLine("Quantity: {0}", quantity);
            Console.WriteLine("Returned Value: {0}", bundleResults == null ? "null" : fullResults.Aggregate("", (keyString, pair) => keyString + pair.Key + ":" + pair.Value + ","));
        }
        static private Dictionary<int, int> StackThis(List<int> usableBundle, int currentQuantity)
        {
            // Order the list from largest bundle size to smallest size
            List<int> arrUsableBundles = usableBundle.OrderByDescending(x => x).ToList();
            // Key: Bundles | Value: Quantity
            Dictionary<int, int> hmBundleToQuantity = new Dictionary<int, int>();
            // Create the hashmap table structure
            foreach (int Bundle in arrUsableBundles)
            {
                hmBundleToQuantity.Add(Bundle, 0);
            }
            // Keep track of our index of the bundles we need to figure out
            Stack<int> stBundleIndex = new Stack<int>();
            
            // Used to calculate the left and right of bundle list
            int ixCursor;
            // Our remaining quantity after calculations
            int iRemaining;
            /*
                This will act as the midpoint of the bundle list
                Will update the right of the cursor, decrement the
                cursor, don’t touch the left, and since the loop 
                hasn’t started we’ll consider everything updatable
                and on the right of the cursor
            */
            stBundleIndex.Push(-1);
            // Keep working till there is no more ways to solve the solution
            while (stBundleIndex.Count > 0)
            {
                // The current cursor is always removed and needs to
                // be added back if we want to check it again
                ixCursor = stBundleIndex.Pop();
                iRemaining = currentQuantity;
                for (int ixBundle = 0; ixBundle < usableBundle.Count; ++ixBundle)
                {
                    //Left of current scope, values remain the same
                    if (ixBundle < ixCursor)
                    {
                        iRemaining -= (hmBundleToQuantity[usableBundle[ixBundle]] * usableBundle[ixBundle]);
                    }
                    //At the cursor stack scope – decrement current quantity
                    if (ixBundle == ixCursor)
                    {
                        --hmBundleToQuantity[usableBundle[ixBundle]];
                        iRemaining -= (hmBundleToQuantity[usableBundle[ixBundle]] * usableBundle[ixBundle]);
                    }
                    //Right of current scope gets calculated
                    if (ixBundle > ixCursor)
                    {
                        hmBundleToQuantity[usableBundle[ixBundle]] += iRemaining / usableBundle[ixBundle];
                        iRemaining = iRemaining % usableBundle[ixBundle];
                    }
                }
                if (iRemaining == 0) return hmBundleToQuantity;
                // Otherwise… We have nothing left on the stack we’ll check
                // back to the beginning for non-zero values
                int iNonEmptyStart = 0;
                //Keep the current scope on the stack if the quantity is still bigger than zero
                if (ixCursor >= 0 && hmBundleToQuantity[usableBundle[ixCursor]] > 0)
                {
                    stBundleIndex.Push(ixCursor);
                    // Maximum cursor on the stack
                    // (this way we don’t decrement further back than we want)
                    iNonEmptyStart = stBundleIndex.Max();
                }
                //Add last non-empty value to the stack to decrement and recalculate from there
                for (int ixNonEmpty = usableBundle.Count - 1; ixNonEmpty >= iNonEmptyStart; ixNonEmpty--)
                {
                    if (hmBundleToQuantity[usableBundle[ixNonEmpty]] > 0)
                    {
                        stBundleIndex.Push(ixNonEmpty);
                        break;
                    }
                }
            }
            return null;
        }
    }
