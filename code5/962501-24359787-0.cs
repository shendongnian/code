        private void Update()
        {
            dynamic ids;
            ids = new int[this.OSG.GetNodeCount()];
            this.OSG.GetNodeList(ref ids);
            for (int i = 0; i <= ids.Length - 1; i++)
                this.Add(ids[i]);
        }
