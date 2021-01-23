    foreach (var result in validationResults)
    {
        if (result.MemberNames.Any())
        {
            foreach (var name in result.MemberNames)
            {
                controller.ModelState.AddModelError(name, result.ErrorMessage);
            }
        }
        else
            controller.ModelState.AddModelError("", result.ErrorMessage);
    }
