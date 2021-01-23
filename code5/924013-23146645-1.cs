    newBindingContext.ModelState.Remove("Price");
    newBindingContext.ModelState.Add("Price", new ModelState());
    newBindingContext.ModelState.SetModelValue("Price", new ValueProviderResult(price, price, null));
    object o = base.BindModel(controllerContext, newBindingContext);
    return o;
