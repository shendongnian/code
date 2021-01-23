        /// <summary>
        ///データグリッドビューのチェックボックスのダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Ichiran_CheckBoxCellClick(sender, e);
        }
        
        /// <summary>
        /// データグリッドビューのチェックボックスのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Ichiran_CheckBoxCellClick(sender, e);
        }
        /// <summary>
        /// セルの値自体がクリックされた際に発生するCellContentClickイベントの
        /// コールバックメソッドです。
        /// </summary>
        /// <param name="sender">イベント送信元オブジェクト</param>
        /// <param name="e"></param>              
        private void Ichiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Ichiran_CheckBoxCellClick(sender, e);
        }
        /// <summary>
        /// チェックボックスクリック
        /// </summary>
        private void Ichiran_CheckBoxCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Ichiran.CurrentCell != null && this.Ichiran.CurrentCell is r_framework.CustomControl.DataGridCustomControl.DgvCustomCheckBoxCell)
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                var cell = this.Ichiran["chb_delete", e.RowIndex];
                if (cell.Value == null) cell.Value = false;
                cell.Value = !(bool)cell.Value;
                cell.ReadOnly = true;
                cell.ReadOnly = false;
            }
        }
        /// <summary>
        /// CurrentCellDirtyStateChangedイベントハンドラでDataGridView.CommitEditメソッドを呼び出して値をコミットします。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            this.Ichiran.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
