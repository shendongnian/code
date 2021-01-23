    private void treeList1_Click(object sender, System.EventArgs e) {
        DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
        DevExpress.XtraTreeList.TreeListHitInfo info = tree.CalcHitInfo(tree.PointToClient(MousePosition));
        if(info.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            ... // your code is here
    }
