     foreach(Person p in people.getAll()){
    /////MAKE NEW CELL FOR EACH VALUE
     DataGridViewTextBoxCell name= new DataGridViewTextBoxCell();
     name.Value = p.name;
     DataGridViewTextBoxCell phones= new DataGridViewTextBoxCell();
     
     foreach(Int Pnumber in p.numbers){
        phones.items.add(Pnumber);
      }
      DataGridViewCheckBoxCell ismarried = new DataGridViewCheckBoxCell();
             ismarried.Value = p.married;
     ///////// MAKE NEW ROW AND ADD CELLS
     DataGridViewRow row = new DataGridViewRow();
      row .Cells.Add(name);
      row .Cells.Add(phones);
      row .Cells.Add(ismarried );
       
       ///// ADD ENTIRE ROW TO DATA GRID
       dataGridView.Rows.Add(row);
       }
