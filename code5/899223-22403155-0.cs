    ret.Abilities =
       _unitOfWork.AbilityRepository
                  .ToSelectListItem(item => new[] { new Tuple<String, int> (
                                                          (YourAbilityClass)item.Id,
                                                          (YourAbilityClass)item.Name)) };
