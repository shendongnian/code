    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    
    namespace RatesScenarios.Controls
    {
        public class InteractiveGrid : Grid, IDisposable
        {
        #region IDisposable Members
            public void Dispose()
            {
                
            }
        #endregion
    
            private DataCell selectedCell;
    
            public DataCell SelectedCell
            {
                get { return selectedCell; }
            }
    
            public InteractiveGrid()
            {
                
            }
    
            public void Build(List<string> columnsHeaders, List<string> rowsHeaders, List<DataCell> dataCells)
            {
                
            }
    
            public void SelectCell(DataCell dataCell)
            {
                selectedCell = dataCell;
            }
        }
    }
