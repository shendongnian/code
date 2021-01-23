        /// <summary>
        /// Increment the QTA in that the row using the index
        /// </summary>
        /// <param name="index">index of the row you want to increment</param>
        private void IncrementQTAofIndex(int index)
        {
            int qty = Convert.ToInt32(gvsale.Rows[index].Cells["QTY"].Value);
            qty++;
            gvsale.Rows[index].Cells["QTY"].Value = qty;
        }
