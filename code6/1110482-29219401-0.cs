		// This is the ONLY way to prevent buttons, checkboxes, and datagrids from processing the UP and DOWN arrows
		const int WM_KEYDOWN       = 0x100;
		const int WM_KEYUP         = 0x101;
		public bool PreFilterMessage(ref Message m)
		{
			try
			{
	
				if (m.Msg == WM_KEYDOWN)
                    // handle event here and return true
				else if (m.Msg == WM_KEYUP)
					// handle event here and return true
				}
			}
			catch
			{
				return false;
			}
        return false;
		}
