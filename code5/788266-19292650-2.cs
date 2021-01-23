    [CommandMethod("EditBlockAtt")]
        public void EditBlockAtt()
        {
            var acDb = HostApplicationServices.WorkingDatabase;
            var acEd = AcadApplication.DocumentManager.MdiActiveDocument.Editor;
            var blockNamePrompt = acEd.GetString(Environment.NewLine + "Enter block name: ");
            if (blockNamePrompt.Status != PromptStatus.OK) return;
            var blockName = blockNamePrompt.StringResult;
            var attNamePrompt = acEd.GetString(Environment.NewLine + "Enter attribute name: ");
            if (attNamePrompt.Status != PromptStatus.OK) return;
            var attName = attNamePrompt.StringResult;
            var acPo = new PromptStringOptions(Environment.NewLine + "Enter new attribute value: "){ AllowSpaces = true };
            var newValuePrompt = acEd.GetString(acPo);
            if (newValuePrompt.Status != PromptStatus.OK) return;
            var newValue = newValuePrompt.StringResult;
            using (var acTrans = acDb.TransactionManager.StartTransaction())
            {
                var acBlockTable = acTrans.GetObject(acDb.BlockTableId, OpenMode.ForRead) as BlockTable;
                if (acBlockTable == null) return;
                var acBlockTableRecord =
                    acTrans.GetObject(acBlockTable[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;
                if (acBlockTableRecord == null) return;
                foreach (var blkId in acBlockTableRecord)
                {
                    var acBlock = acTrans.GetObject(blkId, OpenMode.ForRead) as BlockReference;
                    if (acBlock == null) continue;
                    if (!acBlock.Name.Equals(blockName, StringComparison.CurrentCultureIgnoreCase)) continue;
                    foreach (ObjectId attId in acBlock.AttributeCollection)
                    {
                        var acAtt = acTrans.GetObject(attId, OpenMode.ForRead) as AttributeReference;
                        if (acAtt == null) continue;
                        if (!acAtt.Tag.Equals(attName, StringComparison.CurrentCultureIgnoreCase)) continue;
                        
                        acAtt.UpgradeOpen();
                        acAtt.TextString = newValue;
                    }
                }
                acTrans.Commit();
            }
        }
