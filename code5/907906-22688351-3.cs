    <script type="text/javascript">
            var Counter;
            
            function ExtAll(CheckBox)
            {
                //Get target base & child control.
                var TargetBaseControl = document.getElementById('<%= this.leftCB.ClientID %>');
                var TargetChildControl = "cbExtList";
                
                //Get all the control of the type INPUT in the base control.
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                
                //Checked/Unchecked all the checkBoxes.
                for (var n = 0; n < Inputs.length; ++n) {
                    if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                        Inputs[n].checked = CheckBox.checked;
                    //Reset Counter
                }
                Counter = CheckBox.checked ? TotalChkBx : 0;
            }
                   
            function ChildClick(CheckBox, HCheckBox)
            {
                //get target base & child control.
                var HeaderCheckBox = document.getElementById(HCheckBox);
                         
                //Modifiy Counter;            
                if(CheckBox.checked && Counter < TotalChkBx)
                    Counter++;
                else if(Counter > 0) 
                    Counter--;
                    
                //Change state of the header CheckBox.
                if(Counter < TotalChkBx)
                    HeaderCheckBox.checked = false;
                else if(Counter == TotalChkBx)
                    HeaderCheckBox.checked = true;
            }
    </script>
