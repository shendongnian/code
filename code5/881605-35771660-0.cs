       private Diagnostics backupCopy;
       private bool inEdit;
       public void BeginEdit()
       {
           if (inEdit) return;
           inEdit = true;
           backupCopy = this.MemberwiseClone() as Diagnostics;
       }
       public void CancelEdit()
       {
           if (!inEdit) return;
           inEdit = false;
           this.Name= backupCopy.Name;
       }
       public void EndEdit()
       {
           if (!inEdit) return;
           inEdit = false;
           backupCopy = null;
       }
