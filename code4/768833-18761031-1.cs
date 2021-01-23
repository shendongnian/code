    protected override void BeginProcessing()
        {
          using (GetRandomCommand.tracer.TraceMethod())
          {
            if (this.SetSeed.HasValue)
              this.Generator = new Random(this.SetSeed.Value);
            if (this.EffectiveParameterSet == GetRandomCommand.MyParameterSet.RandomNumber)
            {
              if (this.IsInt(this.Maximum) && this.IsInt(this.Minimum))
              {
                int minValue = this.ConvertToInt(this.Minimum, 0);
                int maxValue = this.ConvertToInt(this.Maximum, int.MaxValue);
                if (minValue >= maxValue)
                  this.ThrowMinGreaterThanOrEqualMax((object) minValue, (object) maxValue);
                this.WriteObject((object) this.Generator.Next(minValue, maxValue));
              }
              else
              {
                double min = this.ConvertToDouble(this.Minimum, 0.0);
                double max = this.ConvertToDouble(this.Maximum, double.MaxValue);
                if (min >= max)
                  this.ThrowMinGreaterThanOrEqualMax((object) min, (object) max);
                this.WriteObject((object) this.GetRandomDouble(min, max));
              }
            }
            else
            {
              if (this.EffectiveParameterSet != GetRandomCommand.MyParameterSet.RandomListItem)
                return;
              this.chosenListItems = new List<object>();
              this.numberOfProcessedListItems = 0;
              if (this.Count != 0)
                return;
              this.Count = 1;
            }
          }
        }
...
    private void ThrowMinGreaterThanOrEqualMax(object min, object max)
        {
          if (min == null)
            throw GetRandomCommand.tracer.NewArgumentNullException("min");
          if (max == null)
            throw GetRandomCommand.tracer.NewArgumentNullException("max");
          string errorId = "MinGreaterThanOrEqualMax";
          this.ThrowTerminatingError(new ErrorRecord((Exception) new ArgumentException(this.GetErrorDetails(errorId, min, max).Message), errorId, ErrorCategory.InvalidArgument, (object) null));
        }
