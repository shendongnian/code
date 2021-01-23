    private void SaveControl(byte userControlType, ISelectableViewModel viewModel, Guid guid)
    {
        using(var context = new EntitiesNew())
        {
            var instrumentSettings = /*
            *
            * (Snip)
            */
          
             context.SaveChanges();
        }
    }
