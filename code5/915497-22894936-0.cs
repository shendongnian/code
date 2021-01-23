    m_PriorityComboBox.ValueMember = "Value";
    m_PriorityComboBox.DisplayMember = "Name";
    m_PriorityComboBox.DataSource =
                    Enum.GetNames(typeof(MPriority))
                        .Zip(
                              Enum.GetValues(typeof(MPriority)).Cast<MPriority>(),
                              (s, i) => new {Name = s, Value = i }
                            )
                        .ToList();
