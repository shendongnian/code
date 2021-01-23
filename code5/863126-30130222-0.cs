    nesting.Value = nesting.Value + 1;
    try {
      ....
    }
    finally {
        nesting.Value = nesting.Value - 1;
    }
