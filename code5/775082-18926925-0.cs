     private static Dictionary<string, ILocalisationToken> _requiredValidationDictionary;
     private static Dictionary<string, ILocalisationToken> RequiredValidationDictionary(UserBase model)
     {
          if (_requiredValidationDictionary != null)
              return _requiredValidationDictionary;
          _requiredValidationDictionary = new Dictionary<string, ILocalisationToken>
          {
                 { model.GetPropertyName(m => m.Publication), ErrorMessageToken.PublicationRequired},
                 { model.GetPropertyName(m => m.Company), ErrorMessageToken.CompanyRequired},
                 { model.GetPropertyName(m => m.JobTitle), ErrorMessageToken.JobTitleRequired},
                 { model.GetPropertyName(m => m.KnownAs), ErrorMessageToken.KnownAsRequired},
                 { model.GetPropertyName(m => m.TelephoneNumber), ErrorMessageToken.TelephoneNoRequired},
                 { model.GetPropertyName(m => m.Address), ErrorMessageToken.AddressRequired},
                 { model.GetPropertyName(m => m.PostCode), ErrorMessageToken.PostCodeRequired},
                 { model.GetPropertyName(m => m.Country), ErrorMessageToken.CountryRequired}
          };
          return _requiredValidationDictionary;
      }
      internal static void SetCustomRequiredFields(List<string> requiredFields, UserBase model, ITranslationEngine translationEngine)
      {
          if (requiredFields == null || requiredFields.Count <= 0) return;
          var tokenDictionary = RequiredValidationDictionary(model);
          //Loop through requiredFields and add Display text dependant on which field it is.
      foreach (var requiredField in requiredFields.Select(x => x.Trim()))
      {
          ILocalisationToken token;
          if (!tokenDictionary.TryGetValue(requiredField, out token))
             token = LocalisationToken.GetFromString(string.Format("{0} required", requiredField));
          //add to the model.
          model.RequiredFields.Add(new RequiredField
          {
             FieldName = requiredField,
             ValidationMessage = translationEngine.ByToken(token)
          });
          }
      }
      internal static void CheckForRequiredField<T>(ModelStateDictionary modelState, T fieldValue, string fieldName,                                                            IList<string> requiredFields,                                                          Dictionary<string, ILocalisationToken> tokenDictionary)
       {
            ILocalisationToken token;
            if (!tokenDictionary.TryGetValue(fieldName, out token))
               token = LocalisationToken.GetFromString(string.Format("{0} required", fieldName));
            if (requiredFields.Contains(fieldName) && (Equals(fieldValue, default(T)) || string.IsNullOrEmpty(fieldValue.ToString())))
                 modelState.AddModelError(fieldName, token.Translate());
       }
      internal static void CheckForModelErrorForCustomRequiredFields(UserBase model,                                                                             Paladin3DataAccessLayer client, ICache cache,                                                                             ModelStateDictionary modelState)
      {
          var requiredFields = Common.CommaSeparatedStringToList                          (client.GetSettingValue(Constants.SettingNames.RequiredRegistrationFields, cache: cache, defaultValue: String.Empty, region: null)).Select(x => x.Trim()).ToList();
          var tokenDictionary = RequiredValidationDictionary(model);
       
          foreach (var property in typeof(UserBase)             .GetProperties(BindingFlags.Instance |                                               BindingFlags.NonPublic |                                               BindingFlags.Public))
          {
                CheckForRequiredField(modelState, property.GetValue(model, null), property.Name, requiredFields, tokenDictionary);
          }
      }
