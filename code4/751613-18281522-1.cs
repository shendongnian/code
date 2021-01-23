    bool _IsScrolling = false;
    void DataGridView1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
    {
    	if (e.Type == ScrollEventType.EndScroll) 
            {
    		_IsScrolling = false;
    	} else 
            {
    		_IsScrolling = true;
    	}
    }
