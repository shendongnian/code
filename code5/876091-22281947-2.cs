    //set the text
    shape.Text = box.Name;
    
    //set hyperlink
    if (!String.IsNullOrEmpty(box.HyperLink.Trim()))
    {
         Hyperlink link = shape.Hyperlinks.Add();
         link.Address = box.HyperLink;
    }
    
    //set the shape width
    shape.get_CellsSRC(
                    (short)Microsoft.Office.Interop.Visio.VisSectionIndices.
                    visSectionObject,
                    (short)Microsoft.Office.Interop.Visio.VisRowIndices.
                    visRowXFormIn,
                    (short)Microsoft.Office.Interop.Visio.VisCellIndices.
                    visXFormWidth).ResultIU = box.Width;
    
    //set the shape height
    shape.get_CellsSRC(
                   (short)Microsoft.Office.Interop.Visio.VisSectionIndices.
                   visSectionObject,
                   (short)Microsoft.Office.Interop.Visio.VisRowIndices.
                   visRowXFormIn,
                   (short)Microsoft.Office.Interop.Visio.VisCellIndices.
                   visXFormHeight).ResultIU = box.Height;
    
    //set the shape fore color
    shape.Characters.set_CharProps(
                    (short)Microsoft.Office.Interop.Visio.
                        VisCellIndices.visCharacterColor,
                    (short)Utilities.GetVisioColor(box.ForeColor));
    
    //set the shape back color
    shape.get_CellsSRC((short)VisSectionIndices.visSectionObject,
             (short)VisRowIndices.visRowFill, 
    	(short)VisCellIndices.visFillForegnd).FormulaU = 
    	"RGB(" + box.BackColor.R.ToString() + "," + box.BackColor.G.ToString() + "," 
    	+ box.BackColor.B.ToString() + ")"; 
 
