    public ZuvText SelectedEntity
    {
        get
        {
            return this.selectedEntity;
        }
        set
        {
            var entity = value;
            if (this.selectedEntity != null)
            {
                this.selectedEntity.PropertyChanged -= this.OnEntityPropertyChanged;
                this.selectedEntity.DisableContinuousValidation();
            }
            if (entity != null)
            {
                entity.PropertyChanged += this.OnEntityPropertyChanged;
                entity.EnableContinuousValidation();
            }
            this.SetProperty(ref this.selectedEntity, entity);
        }
    }
