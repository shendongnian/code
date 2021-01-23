    public static double Round(double value, int digits, MidpointRounding mode)
        {
          if (digits < 0 || digits > 15)
            throw new ArgumentOutOfRangeException("digits", Environment.GetResourceString("ArgumentOutOfRange_RoundingDigits"));
          if (mode >= MidpointRounding.ToEven && mode <= MidpointRounding.AwayFromZero)
            return Math.InternalRound(value, digits, mode);
          throw new ArgumentException(Environment.GetResourceString("Argument_InvalidEnumValue", (object) mode, (object) "MidpointRounding"), "mode");
        }
    private static unsafe double InternalRound(double value, int digits, MidpointRounding mode)
        {
          if (Math.Abs(value) < Math.doubleRoundLimit)
          {
            double num1 = Math.roundPower10Double[digits];
            value *= num1;
            if (mode == MidpointRounding.AwayFromZero)
            {
              double num2 = Math.SplitFractionDouble(&value);
              if (Math.Abs(num2) >= 0.5)
                value += (double) Math.Sign(num2);
            }
            else
              value = Math.Round(value);
            value /= num1;
          }
          return value;
        }
