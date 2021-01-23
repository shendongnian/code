     public void DoSort()
        {
            List<ModelItems> sorted_items = originalItems.Where(i => i.isPageIntegrable()).OrderBy(i => Int32.Parse( i.Page)).ToList();
            List<ModelItems> second_part = originalItems.Where(i => !i.isPageIntegrable()).OrderBy(i => i.Page).ToList();
            var final_sorted = sorted_items.Union(second_part).ToList();
            final_sorted.displayList();
            Console.ReadKey();
        }
