      // All strings within quantity contains digits only
      if (!quantity.All(c => c.All(Char.IsDigit(c)))) {
        _notifier.Information(T("A letter has been entered for quantity. Please enter a number"));
        return Redirect(returnUrl);
      }
