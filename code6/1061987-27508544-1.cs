    public override object Clone() {
      var column = base.Clone() as MhsDataGridViewTextBoxColumn;
      if (column != null) {
        column.TableName = this.TableName;
      }
      return column;
    }
