     public IfStatement? m_IfStatement;
        public struct IfStatement
        {
            public string Statement { get; private set; }
            public string Comparison { get; private set; }
            public string ConditionValue { get; private set; }
            public string IfCondition_True { get; private set; }
            public string IfCondition_False { get; private set; }
        }
            m_IfStatement = new IfStatement();
            m_IfStatement.Value.Statement = cboIfStatement.SelectedItem.ToString();
            m_IfStatement.Value.Comparison = cboComparison.SelectedItem.ToString();
            m_IfStatement.Value.ConditionValue = txtIfValue.Text;
            m_IfStatement.Value.IfCondition_True = "";
            m_IfStatement.Value.IfCondition_False = "";
