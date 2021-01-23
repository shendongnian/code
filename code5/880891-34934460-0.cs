    public static void InitGrid(DataGridView Grid) {
    	Grid.HandleCreated+=new System.EventHandler(DoResizeColumnsEvent);
    }
    
    static void DoResizeColumnsEvent(object sender,EventArgs e) {
    			((DataGridView)sender).AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);			
    }
