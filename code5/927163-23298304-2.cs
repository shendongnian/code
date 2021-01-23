    var control = new WizardControl();
    control.Control = _userSelectedControl;  // Add whatever control the user selected
    control.WizardStep = _wizardStep; // Set to whatever wizard page this control belongs to.
    _wizardControls.Add(control); // Add it to our collection
    ViewState["WizardControls"] = _wizardControls; // Save it into the ViewState
