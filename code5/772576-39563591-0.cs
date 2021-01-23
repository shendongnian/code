    public class MyDataGridView : DataGridView    
	{    
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]    
		protected override bool ProcessDataGridViewKey(KeyEventArgs e)    
		{    
			switch (e.KeyCode)    
			{    
				case Keys.Insert:    
				case Keys.C:    
					return this.ProcessInsertKey(e.KeyData);    
				default:    
					break;    
			}    
			return base.ProcessDataGridViewKey(e);    
		}    
	
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]    
		protected new bool ProcessInsertKey(Keys keyData)    
		{    
			if ((((keyData & (Keys.Alt | Keys.Control | Keys.Shift)) == Keys.Control) ||    
				(((keyData & (Keys.Alt | Keys.Control | Keys.Shift)) == (Keys.Control | Keys.Shift))    
				&& ((keyData & Keys.KeyCode) == Keys.C)))    
				&& (this.ClipboardCopyMode != DataGridViewClipboardCopyMode.Disable))    
			{    
				DataObject clipboardContent = this.GetClipboardContent();    
				if (clipboardContent != null)    
				{    
					//Clipboard.SetDataObject(clipboardContent);    
					Clipboard.SetText(clipboardContent.GetData(DataFormats.UnicodeText).ToString());    
					return true;    
				}    
			}    
			return false;    
		}    
	}
