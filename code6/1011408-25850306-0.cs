    AlertDialog dialog = new AlertDialog.Builder(this)
        .SetTitle("blabla")
        .SetMessage("blablabla")
        .SetPositiveButton("OK", (sender, e) => {
            SetResult(Result.Ok, oIntent);
            Finish();
        })
        .SetNegativeButton("Cancel", (sender, e) => { })
        .Show(); // Important, or GetButton() will return null
        
    // Now disable the default dismissing actions on key presses.
    dialog.GetButton((int)DialogButtonType.Positive).KeyPress += (sender, e) => { };
    dialog.GetButton((int)DialogButtonType.Negative).KeyPress += (sender, e) => { };
