		 **Use the below code it will work.**
	
            private void CreateButtons()
			{
				//Button outside loop works
				Button selectItem = new Button();
				selectItem.Text = "Hello World";
				selectItem.ID = "btn";
				selectItem.Click += selectItem_Click;
				PlaceHolder1.Controls.Add(selectItem);
				int ItemCounter = 0;
				for (int i = 0; i < BillDate.Count; i++)
				{   //Button inside loop doesnt work
					Button selectItem = new Button();
					selectItem.Text = "Hello World";
					selectItem.ID = "btn-" + ItemCounter.ToString();
					selectItem.Click += selectItem_Click;
					ItemCounter++;
					PlaceHolder1.Controls.Add(selectItem);
				}
			}
