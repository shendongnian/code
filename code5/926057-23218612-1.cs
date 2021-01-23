     public IfStatement? m_IfStatement;
        public struct IfStatement
        {
            public string Statement { get; set; }
            public string Comparison { get; set; }
            public string ConditionValue { get; set; }
            public string IfCondition_True { get; set; }
            public string IfCondition_False { get; set; }
        }
            m_IfStatement = new IfStatement();
            IfStatement ifStat = m_IfStatement.Value;
            ifStat.Statement = cboIfStatement.SelectedItem.ToString();
            ifStat.Comparison = cboComparison.SelectedItem.ToString();
            ifStat.ConditionValue = txtIfValue.Text;
            ifStat.TrueCondition = "";
            ifStat.FalseCondition = "";
