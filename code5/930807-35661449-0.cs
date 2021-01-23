        private static void PrintPerformanceCounterParameters()
        {
            var sb = new StringBuilder();
            PerformanceCounterCategory[] categories = PerformanceCounterCategory.GetCategories();
            
            var desiredCategories = new HashSet<string> {"Process", "Memory"};
            foreach (var category in categories)
            {
                sb.AppendLine("Category: " + category.CategoryName);
                if (desiredCategories.Contains(category.CategoryName))
                {
                    PerformanceCounter[] counters;
                    try
                    {
                        counters = category.GetCounters("devenv");
                    }
                    catch (Exception)
                    {
                        counters = category.GetCounters();
                    }
                    
                    foreach (var counter in counters)
                    {
                        sb.AppendLine(counter.CounterName + ": " + counter.CounterHelp);
                    }
                }
            }
            File.WriteAllText(@"C:\performanceCounters.txt", sb.ToString());
        }
