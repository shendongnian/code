        public void RemoveItem(int id)
        {
            for (int x = 0; x < b.Count; x++)
            {
                if (b[x].id == id)
                {
                    b.RemoveAt(x);
                }
            }
        }
