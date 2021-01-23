    int result=0;
    if(!int.TryParse(integer, out result)){
       bindingContext.ModelState.AddModelError(bindingContext.ModelName, String.Format("\"{0}\" is invalid, please provide a valid number.", bindingContext.ModelName));
       return null;
    }
    return result;
