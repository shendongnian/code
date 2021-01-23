		public virtual string SelectedValue
		{
			set
			{
				if (Items.Count != 0)
				{
					// at design time, a binding on SelectedValue will be reset to the default value on OnComponentChanged
					if (value == null || (DesignMode && value.Length == 0))
					{
						ClearSelection();
						return;
						// !!! cachedSelectedValue is not getting reset here !!!
					}
				...
				// always save the selectedvalue
				// for later databinding in case we have viewstate items or static items
				cachedSelectedValue = value;
			}
		}
