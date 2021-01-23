    StringBuilder sb = new StringBuilder();
    sb.Append("Possible values for pg1rb:");
    sb.Append(Environment.NewLine);
    states = form.GetAppearanceStates("pg1rb");
    for (int i = 0; i < states.Length - 1; i++) {
        sb.Append(states[i]);
        sb.Append(", ");
    }
    sb.Append(states[states.Length - 1]);
