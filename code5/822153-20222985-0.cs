    switch (value) // Assuming value is of type SomeEnum
    {
       case SomeEnum.ToLower:
          return f.ToLower()
       case SomeEnum.ToUpper:
          return f.ToUpper();
       default:
          //Do the Default
          break;
    }
