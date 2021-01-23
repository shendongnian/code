            Control.RenderTransformProperty.OverrideMetadata(typeof(Test), new PropertyMetadata(
					Control.RenderTransformProperty.GetMetadata(typeof(Test)).DefaultValue
					, new PropertyChangedCallback(Test.RenderTransform_Changed)
				)
			);
