    select R.Date R.Shift,(select V.Initial Reading From Vehicle V where v.Vehicle id =R.Vehicle Id) as Initial Reading , R.Reading as Closing Reading from Reading Where Vehicle id=@Vehicle id
    
    or 
    
    set @Vehicle id=1
    
    select R.Date R.Shift,(select V.Initial Reading From Vehicle V where v.Vehicle id =R.Vehicle Id) as Initial Reading , R.Reading as Closing Reading from Reading Where Vehicle id=1
  
