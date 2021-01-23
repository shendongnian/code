       private void ExcelListChanged(object parameter)
    {
        IList iConverted= parameter as IList;
        if(iConverted!=null){
          foreach(YouKnowTheTypeOfElements theElement in iConverted) {
             doSomethingWith(theElement);
          }
        }
        return;
    }
