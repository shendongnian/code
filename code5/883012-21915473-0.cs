    default:
     if (typeof(System.Collections.ICollection).IsAssignableFrom(fieldInfo.GetValue(type).GetType())
       value = (((System.Collections.ICollection)fieldInfo.GetValue(type)).Count - 1).ToString();
      else
        value = fieldInfo.GetValue(type).ToString();
      break;
