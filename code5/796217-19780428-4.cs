    private void _automationElementTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            //selected currentTestTypeRootNode has been changed so notify change to AutomationTests Control
            AutomationElementTreeNode selectedNode = _automationElementTree.SelectedNode;
            AutomationElement selectedElement = null;
            if (selectedNode != null)
            {
                selectedElement = selectedNode.AutomationElement;
                if (selectedElement.Current.ClassName.Equals("AutomatedDataGrid.CommonDataGridViewCell"))
                {
                    if(selectedElement.Current.Name.Equals("Tej")) //Current Value
                    {
                        var valuePattern = selectedElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                        valuePattern.SetValue("Jet");
                    }
                    
                    
                    
                    //Useful ways to get patterns and values
                    
                    //System.Windows.Automation.SelectionItemPattern pattern = selectedElement.GetCurrentPattern(System.Windows.Automation.SelectionItemPattern.Pattern) as System.Windows.Automation.SelectionItemPattern;
                                       
                    //var row = pattern.Current.SelectionContainer.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "AutomatedDataGrid.CommonDataGridViewRow", PropertyConditionFlags.IgnoreCase));
                    //var cells = row.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "AutomatedDataGrid.CommonDataGridViewCell", PropertyConditionFlags.IgnoreCase));
                    //foreach (AutomationElement cell in cells)
                    //{
                    //    Console.WriteLine("**** Printing Cell Value **** " + cell.Current.Name);
                    //    if(cell.Current.Name.Equals("Tej")) //current name
                    //    {
                    //        var valuePattern = cell.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    //        valuePattern.SetValue("Suraj");
                    //    }
                    //}
                    //Select Row
                    //pattern.Select();
                    //Get All Rows
                    //var arrayOfRows = pattern.Current.SelectionContainer.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "AutomatedDataGrid.CommonDataGridViewRow", PropertyConditionFlags.IgnoreCase));
                                       
                    //get cells
                    //foreach (AutomationElement row in arrayOfRows)
                    //{
                    //   var cell = row.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "AutomatedDataGrid.CommonDataGridViewCell", PropertyConditionFlags.IgnoreCase));
                          
                    
                    //    var gridItemPattern = cell.GetCurrentPattern(GridItemPattern.Pattern) as GridItemPattern;
                    //    // Row number.
                    //    Console.WriteLine("**** Printing Row Number **** " + gridItemPattern.Current.Row);
                    //    //Cell Automation ID
                    //    Console.WriteLine("**** Printing Cell AutomationID **** " + cell.Current.AutomationId);
                    //    //Cell Class Name
                    //    Console.WriteLine("**** Printing Cell ClassName **** " + cell.Current.ClassName);
                    //    //Cell Name
                    //    Console.WriteLine("**** Printing Cell AutomationID **** " + cell.Current.Name);                        
                    //}
                    
                }
            }
            _automationTests.SelectedElement = selectedElement;
            _automationElementPropertyGrid.AutomationElement = selectedElement;
        }
