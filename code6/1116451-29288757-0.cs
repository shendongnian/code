        class Whatever { public string Text { get; set; } }
        class It { public string Text { get; set; } }
        class Can { public string Text { get; set; } }
        class Be { public string Text { get; set; } }
        static void Main()
        {
            var whatever = new Whatever();
            var it = new It();
            var can = new Can();
            var be = new Be();
            foreach (var item in new dynamic[] {whatever, it, can, be})
                item.Text = item.ToString();
        }
