        /// <summary>
        /// Quits the excel process
        /// </summary>
        public void Quit() 
        {
            Marshal.ReleaseComObject(this.worksheet);
            Marshal.ReleaseComObject(this.workbook);
            this.excel.Quit();
            this.excel = null;
        }
