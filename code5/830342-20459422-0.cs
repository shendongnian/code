    List<int> Sizes = new List<int>();
            for(int i = 1; i < 9; i++)
            {
                Sizes.Add(i);
            }
            ViewBag.Sizes = new SelectList(Sizes);
