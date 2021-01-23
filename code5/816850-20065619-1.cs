    <script type = "text/javascript">
    function Check_Click(objRef)
    {
        //Get the Row based on checkbox
        var row = objRef.parentNode.parentNode;
        if(objRef.checked)
        {
            //If checked change color to Aqua
            row.style.backgroundColor = "aqua";
        }
        else
        {   
            //If not checked change back to original color
            if(row.rowIndex % 2 == 0)
            {
               //Alternating Row Color
               row.style.backgroundColor = "#C2D69B";
            }
            else
            {
               row.style.backgroundColor = "white";
            }
        }
       
        //Get the reference of GridView
        var GridView = row.parentNode;
       
        //Get all input elements in Gridview
        var inputList = GridView.getElementsByTagName("input");
       
        for (var i=0;i<inputList.length;i++)
        {
            //The First element is the Header Checkbox
            var headerCheckBox = inputList[0];
           
            //Based on all or none checkboxes
            //are checked check/uncheck Header Checkbox
            var checked = true;
            if(inputList[i].type == "checkbox" && inputList[i] != headerCheckBox)
            {
                if(!inputList[i].checked)
                {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;
       
    }
    </script>
