    private void RecurseTree(TreeNode node,string ParentNode)
        {
            CANoe.System sys = null;
            CANoe.Namespaces nss = null;
            CANoe.Namespace ns = null;
            CANoe.Variables vars = null;
                sys = (CANoe.System)mApp.System;
                nss = (CANoe.Namespaces)sys.Namespaces;
            if (node.Checked == true)
            {
                ns = (CANoe.Namespace)nss[ParentNode];
                vars = (CANoe.Variables)ns.Variables;
                mSysVar_start = (CANoe.Variable)vars[node.Name + "_start"];
                mSysVar = (CANoe.Variable)vars[node.Name];
                mSysVar_start.Value = 1;
                int chk = 0;
                System.Threading.Thread.Sleep(1000);
                if ((int)mSysVar.Value != 0) while ((int)mSysVar.Value == 1 || (int)mSysVar.Value == 2) continue;
                else chk = 1;
                
                    if ((int)mSysVar.Value==3||(int)mSysVar.Value==4 ||chk==1)
                    {
                        if (mMsr!=null) mMsr.Stop();
                        System.Threading.Thread.Sleep(1000);
                        if (mMsr!=null) mMsr.Start();
                        System.Threading.Thread.Sleep(1000);
                    }
            }
            foreach (TreeNode childNode in node.Nodes) RecurseTree(childNode, ParentNode);
        }
        
        private void msrstart_Click(object sender, EventArgs e)
        {
                if (mMsr != null) mMsr.Start();
                foreach (TreeNode node in treeView1.Nodes) RecurseTree(node, node.Name);   
        }
